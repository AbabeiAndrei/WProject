using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WProject.GenericLibrary.WinApi;
using WProject.UiLibrary.Classes;
using WProject.UiLibrary.Theme;

namespace WProject.UiLibrary.Controls
{
    public partial class WpTextThread : WpUserControl
    {
        #region Fields

        private const int HORIZONTAL_MESSAGE_PADDING = 26;
        private const int START_MESSAGE_PADDING = 4;
        private const int INFO_LINE_HEIGHT = 16;

        private ObservableCollection<ChatMessage> _chatMessages;
        private int _messagesLimit;
        private Font _smallInfoFont;
        private bool _messagesHaveChanges;
        private Color _sendMessageColor;
        private Color _reciveMessageColor;
        private Color _sendMessageForeColor;
        private Color _reciveMessageForeColor;
        private int _paddingBetweenMessages;

        private IDictionary<Rectangle, string> _toolTips;

        #endregion

        #region Properties

        [DefaultValue(true)]
        [Category("Behavior")]
        public virtual bool ClearOnSend { get; set; } = true;

        [Category("Action")]
        public event EventHandler OnSend;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual IList<ChatMessage> Messages
        {
            get
            {
                return _chatMessages;
            }
            set
            {
                _chatMessages = new ObservableCollection<ChatMessage>(value);

                _chatMessages.CollectionChanged += ChatMessagesOnCollectionChanged;
                RecalculateMessagesHeight();
                Refresh();

                pnlMain.ScrollToBottom();
            }
        }

        [DefaultValue(100)]
        public int MessagesLimit
        {
            get
            {
                return _messagesLimit;
            }
            set
            {
                _messagesLimit = value;

                RecalculateMessagesHeight();
                Refresh();
            }
        }

        [DefaultValue(2)]
        public int PaddingBetweenMessages
        {
            get
            {
                return _paddingBetweenMessages;
            }
            set
            {
                _paddingBetweenMessages = value;

                RecalculateMessagesHeight();
                Refresh();
            }
        }

        public Color SendMessageColor
        {
            get
            {
                return _sendMessageColor;
            }
            set
            {
                _sendMessageColor = value;
                pnlThread.Refresh();
            }
        }

        public Color ReciveMessageColor
        {
            get
            {
                return _reciveMessageColor;
            }
            set
            {
                _reciveMessageColor = value;
                pnlThread.Refresh();

            }
        }

        public Color SendMessageForeColor
        {
            get
            {
                return _sendMessageForeColor;
            }
            set
            {
                _sendMessageForeColor = value;
                pnlThread.Refresh();
            }
        }

        public Color ReciveMessageForeColor
        {
            get
            {
                return _reciveMessageForeColor;
            }
            set
            {
                _reciveMessageForeColor = value;
                pnlThread.Refresh();
            }
        }

        #endregion

        #region Overrides of UserControl

        public override string Text
        {
            get
            {
                return txtMessage.Text;
            }
            set
            {
                txtMessage.Text = value;
            }
        }

        #endregion

        #region Constructors

        public WpTextThread()
        {
            InitializeComponent();

            InitChatMessages();

            _smallInfoFont = new Font("Segoe UI", 7f);
            _paddingBetweenMessages = 2;

            btnSend.Parent = null;

            txtMessage.LeftButton = btnSend;

            SendMessageColor = WpThemeColors.Blue;
            ReciveMessageColor = WpThemeColors.Teal;
            MessagesLimit = 100;

            _toolTips = new Dictionary<Rectangle, string>();
        }

        public WpTextThread(IEnumerable<ChatMessage> messages)
            : this()
        {

            InitChatMessages(messages);
        }

        #endregion

        #region Events

        private void btnSend_Click(object sender, EventArgs e)
        {
            pnlMain.ScrollToBottom();

            OnSend?.Invoke(this, EventArgs.Empty);

            if (ClearOnSend)
                txtMessage.Clear();
        }

        private void ChatMessagesOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Add && _chatMessages.Count >= MessagesLimit)
            {
                _chatMessages.CollectionChanged -= ChatMessagesOnCollectionChanged;
                _chatMessages.RemoveAt(0);
                _chatMessages.CollectionChanged += ChatMessagesOnCollectionChanged;
            }

            try
            {
                pnlThread.SuspendLayout();
                pnlBottom.SuspendLayout();
                SuspendLayout();

                RecalculateMessagesHeight();
                pnlThread.Refresh();

                pnlMain.ScrollToBottom();
            }
            finally
            {
                ResumeLayout();
                pnlBottom.ResumeLayout();
                pnlThread.ResumeLayout();
            }

            _messagesHaveChanges = true;
        }

        private void pnlThread_Paint(object sender, PaintEventArgs e)
        {
            _messagesHaveChanges = false;
            _toolTips = new Dictionary<Rectangle, string>();
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (Messages == null || Messages.Count == 0)
            {
                using (Brush mb = new SolidBrush(WpThemeColors.Shadow))
                    e.Graphics.DrawString("No messages",
                                          _smallInfoFont,
                                          mb,
                                          pnlThread.ClientRectangle,
                                          new StringFormat
                                          {
                                              LineAlignment = StringAlignment.Center,
                                              Alignment = StringAlignment.Center
                                          });
                return;
            }
            int mlastx = START_MESSAGE_PADDING;

            foreach (ChatMessage msg in Messages.Take(MessagesLimit))
                DrawChatMessage(msg, e.Graphics, ref mlastx);

            if (pnlThread.Height != mlastx)
                pnlThread.Height = mlastx;
        }

        private void txtMessage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            btnSend.PerformClick();
            e.Handled = true;
            e.SuppressKeyPress = true;
        }

        #endregion

        #region Overrides of Control

        protected override void OnSizeChanged(EventArgs e)
        {
            try
            {
                RecalculateMessagesHeight();
            }
            finally
            {
                base.OnSizeChanged(e);
            }
        }

        #endregion

        #region Overrides of WpUserControl

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ScrollToBottom();
        }

        #endregion

        #region Private methods

        private void InitChatMessages(IEnumerable<ChatMessage> messages = null)
        {
            _chatMessages = messages != null
                                ? new ObservableCollection<ChatMessage>(messages)
                                : new ObservableCollection<ChatMessage>();

            _chatMessages.CollectionChanged += ChatMessagesOnCollectionChanged;
            RecalculateMessagesHeight();
        }

        private void RecalculateMessagesHeight()
        {
            if(Messages == null)
                return;

            using (var mgfx = pnlThread.CreateGraphics())
                pnlThread.Height = Messages.Take(MessagesLimit)
                                           .Select(m => CalculateMessageHeight(m, mgfx) + PaddingBetweenMessages)
                                           .DefaultIfEmpty(10)
                                           .Sum() + START_MESSAGE_PADDING;

            _messagesHaveChanges = true;
        }

        private int CalculateMessageHeight(ChatMessage msg, Graphics gfx)
        {
            var mmsgHeight = gfx.MeasureString(msg.Message,
                                               Font,
                                               new SizeF(pnlThread.Width -
                                                         HORIZONTAL_MESSAGE_PADDING -
                                                         START_MESSAGE_PADDING*3,
                                                         int.MaxValue));

            return (int)mmsgHeight.Height + INFO_LINE_HEIGHT;
        }

        private void DrawChatMessage(ChatMessage msg, Graphics gfx, ref int lastx)
        {
            int mleft = msg.Send ? HORIZONTAL_MESSAGE_PADDING : START_MESSAGE_PADDING;
            int mwidth = pnlThread.Width - HORIZONTAL_MESSAGE_PADDING - START_MESSAGE_PADDING*2;

            var ms = gfx.MeasureString(msg.Message, Font, new Size(mwidth - START_MESSAGE_PADDING*2, int.MaxValue));
            
            Brush mbkbrush = new SolidBrush(msg.Send ? SendMessageColor : ReciveMessageColor);

            Rectangle mrect = new Rectangle(mleft, lastx + 2, mwidth, (int) ms.Height + INFO_LINE_HEIGHT);
            Rectangle mrectText = new Rectangle(mleft, lastx + 2, mwidth, (int) ms.Height);

            gfx.FillRectangle(mbkbrush, mrect);
            gfx.DrawString(msg.Message, Font, Brushes.Black, mrectText);

            if(!msg.Send)
                gfx.DrawString(msg.SendBy, _smallInfoFont, Brushes.Black, mleft, mrectText.Bottom + 1);

            var msend = msg.GetWhenSend();

            var mssend = gfx.MeasureString(msend, _smallInfoFont);

            gfx.DrawString(msend, _smallInfoFont, Brushes.Black, mrect.Right - mssend.Width - 2, mrectText.Bottom + 1);

            _toolTips.Add(new Rectangle(mrect.Right - (int)mssend.Width - 2, 
                                        mrectText.Bottom + 1,
                                        (int) mssend.Width,
                                        (int) mssend.Height),
                           msg.DateTime.ToString(CultureInfo.DefaultThreadCurrentCulture));

            lastx += START_MESSAGE_PADDING + (int)ms.Height + INFO_LINE_HEIGHT + PaddingBetweenMessages;
        }

        #endregion

        #region Public methods

        public virtual void ClearText()
        {
            txtMessage.Clear();
        }

        public virtual void ScrollToBottom()
        {
            pnlMain.ScrollToBottom();
        }

        #endregion
    }
}
